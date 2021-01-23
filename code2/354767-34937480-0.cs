    using System;
    using System.Reactive.Concurrency;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using Microsoft.Reactive.Testing;
    using NUnit.Framework;
    namespace StackOverflow.Tests.Q7620182_PauseResume
    {
        [TestFixture]
        public class PauseAndResumeTests
        {
            [Test]
            public void Should_pause_and_resume()
            {
                //Arrange
                var scheduler = new TestScheduler();
                var isRunningTrigger = new BehaviorSubject<bool>(true);
                Action pause = () => isRunningTrigger.OnNext(false);
                Action resume = () => isRunningTrigger.OnNext(true);
                var source = scheduler.CreateHotObservable(
                    ReactiveTest.OnNext(0.1.Seconds(), 1),
                    ReactiveTest.OnNext(2.0.Seconds(), 2),
                    ReactiveTest.OnNext(4.0.Seconds(), 3),
                    ReactiveTest.OnNext(6.0.Seconds(), 4),
                    ReactiveTest.OnNext(8.0.Seconds(), 5));
                scheduler.Schedule(TimeSpan.FromSeconds(0.5), () => { pause(); });
                scheduler.Schedule(TimeSpan.FromSeconds(5.0), () => { resume(); });
            
                //Act
                var sut = Observable.Create<IObservable<int>>(o =>
                {
                    var current = source.Replay();
                    var connection = new SerialDisposable();
                    connection.Disposable = current.Connect();
                    return isRunningTrigger
                        .DistinctUntilChanged()
                        .Select(isRunning =>
                        {
                            if (isRunning)
                            {
                                    //Return the current replayed values.
                                    return current;
                            }
                            else
                            {
                                    //Disconnect and replace current.
                                    current = source.Replay();
                                    connection.Disposable = current.Connect();
                                    //yield silence until the next time we resume.
                                    return Observable.Never<int>();
                            }
                        })
                        .Subscribe(o);
                }).Switch();
                var observer = scheduler.CreateObserver<int>();
                using (sut.Subscribe(observer))
                {
                    scheduler.Start();
                }
                //Assert
                var expected = new[]
                {
                        ReactiveTest.OnNext(0.1.Seconds(), 1),
                        ReactiveTest.OnNext(5.0.Seconds(), 2),
                        ReactiveTest.OnNext(5.0.Seconds(), 3),
                        ReactiveTest.OnNext(6.0.Seconds(), 4),
                        ReactiveTest.OnNext(8.0.Seconds(), 5)
                    };
                CollectionAssert.AreEqual(expected, observer.Messages);
            }
        }
    }

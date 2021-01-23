    using System;
    using System.Collections.Generic;
    
    namespace PubSubOne
    {
        class Program
        {
            static void Main()
            {
                var processQuestions = new ProcessQuestions();
                processQuestions.StartQuestions();
    
                Console.ReadLine();
            }
        }
    
        public class ProcessQuestions
        {
            NewsSubscriber subscriber = new NewsSubscriber();
            NewsPublisher publisher = new NewsPublisher();
    
            Stack<string> _answers = new Stack<string>();
    
            public ProcessQuestions()
            {
                publisher.QuestionAsked += subscriber.Asked;
                subscriber.QuestionAnswered += (answer) => _answers.Push(answer);
            }
    
    
            public void StartQuestions()
            {
                publisher.PublishQuestion("what is your favourite Newspaper?");
                publisher.PublishQuestion("what is your email?");
                publisher.PublishQuestion("what is your email password?");
    
                Console.WriteLine("Answers: ");
    
                foreach (var answer in _answers)
                {
                    Console.WriteLine(answer);
                }
            }
        }
    
        public class NewsSubscriber
        {
            public delegate void NotifyAnswered(string question);
    
            public event NotifyAnswered QuestionAnswered;
    
            public void Asked(string question)
            {
                Console.Write(question);
    
                if (QuestionAnswered != null)
                {
                    QuestionAnswered(Console.ReadLine());
                }
            }
        }
    
        public class NewsPublisher
        {
            private readonly List<string> _questions = new List<string>();
    
            public delegate void NotifyObserversHandler(string question);
    
            public event NotifyObserversHandler QuestionAsked;
    
            public void PublishQuestion(string question)
            {
                _questions.Add(question);
                QuestionAsked(_questions[_questions.Count - 1]);
            }
        }
    }

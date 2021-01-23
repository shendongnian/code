    // an example of a strongly typed subject. notice how subject
    // defines content. semanticly, when someone creates and publishes
    // an instance of this subject, they are requesting someone show
    // an analysis view based on data content,
    public class AnalyzeSubject
    {
        // subject content, in this case a data result from
        // a business method
        public object Data { get; set; }
    }
    public class MainWindow : ISubscriber<AnalysisSubject> ...
    {
        // use whatever implementation of an IoC container we like
        // here i assume we abstract from implementation and use a
        // custom interface IContainer that exposes functionality 
        // that we need
        private readonly IContainer _container = null;
        public class MainWindow ()
        {
            // we're teh r00tz! we create an instance of IoC
            // container for use throughout application
            IContainer _container = new CustomContainer ();
            // our container exposes both parameterized and
            // type-parameterized resolve methods
            IEventHub events = _container.Resolve<IEventHub> ();
            events.Subscribe<AnalysisSubject> (this);
        }
        #region ISubscriber<AnalysisSubject>
        // part of strongly typed subscriptions is that we
        // may now handle strongly typed publications! yay!
        public void Receive (AnalysisSubject subject)
        {
            // 1. request to display analysis of data
            Type analysisType = subject.Data.GetType ();
            // 2. get view control based on payload type
            // 
            // NOTE: implicit usage below is not consistent
            // with previous invocations, here we are submitting
            // a type of something we already have, and actually
            // want back something that knows how to handle it.
            // most IoC containers can provide this functionality
            // through "facilities" add ons that accept a 
            // parameter\discriminator like below, and produce 
            // something in return.
            object control = _container.Resolve (analysisType);
            // [optionally] if the above is too "magical" where
            // IAnalysisFactory is an interface we define for this
            // express purpose
            //IAnalysisFactory factory = _container.Resolve<IAnalysisFactory> ();
            //object control = factory.GetAnalysisControlFor (analysisType);
            // 3. display control
        }
        #endregion
    }

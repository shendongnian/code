    interface class IProgressEventSink
    { ... };
    class ProgressEventForwarder : IProgressEventCB
    {
        gcroot<IProgressEventSink^> m_sink;
    public:
        ProgressEventForwarder(IProgressEventSink^ sink) : m_sink(sink) {}
    // IProgressEventCB implementation
        virtual void OnProgress( ProgressInfo info ) { m_sink->OnProgress(info.a, info.b); }
    };
    ref class ComputeCLI
    {
         Compute* m_pimpl;
     // ...
    public:
         RegisterHandler( IProgressEventSink^ sink )
         {
             // assumes Compute deletes the handler when done
             // if not, keep this pointer and delete later to avoid memory leak
             m_pimpl->RegisterHandler(new ProgressEventForwarder(sink));
         }
    };

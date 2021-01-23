    namespace ComputeCLI {
        public ref class IProgressCB{
        public:
           /** Create the wrapper and assign the wrapped object */ 
           IProgressCB(Compute::IProgressCB* wrappedObject) 
                : m_wrappedObject(wrappedObject){}
            void progress(int percentCompleted)
            {
                m_wrappedObject->progress(percentCompleted);
            }
        internal:
            // The wrapped object
            Compute::IProgressCB* m_wrappedObject;
        };
        public ref class StaticFunctions{
        public:
            static double compute(IProgressCB^ progressCB, ...){
                Compute::compute(progressCB->m_wrappedObject, ...);
            }
        };
    }

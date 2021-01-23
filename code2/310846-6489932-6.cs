    namespace ComputeCLI {
        public ref class IProgressCB{
        public:
            void progress(int percentCompleted)
            {
                // call corresponding function of the wrapped object
                m_wrappedObject->progress(percentCompleted);
            }
        internal:
           // Create the wrapper and assign the wrapped object
           IProgressCB(Compute::IProgressCB* wrappedObject) 
                : m_wrappedObject(wrappedObject){}
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

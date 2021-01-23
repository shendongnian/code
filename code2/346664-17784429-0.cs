        [MethodImpl(MethodImplOptions.NoInlining)]
        private static NLog.Logger GetLogger()
        {
            var stackTrace = new StackTrace(false);
            StackFrame[] frames = stackTrace.GetFrames();
            if (null == frames) throw new ArgumentException("Stack frame array is null.");
            StackFrame stackFrame;
            switch (frames.Length)
            {
                case 0:
                    throw new ArgumentException("Length of stack frames is 0.");
                case 1:
                case 2:
                    stackFrame = frames[frames.Length - 1];
                    break;
                default:
                    stackFrame = stackTrace.GetFrame(2);
                    break;
            }
            Type declaringType = stackFrame.GetMethod()
                                           .DeclaringType;
            return declaringType == null ? LogManager.GetCurrentClassLogger() :                 LogManager.GetLogger(declaringType.FullName);
        }

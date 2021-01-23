    namespace StackOverflow6128549
    {
        class FileInfoExtended
        {
            public int PropertyX { get; set; }
        }
    
        class IncrediblySmartIteration : IEnumerable<FileInfoExtended>
        {
            private List<FileInfoExtended> GetFilesToProcess()
            {
                throw new NotImplementedException();
            }
    
            #region IEnumerable<FileInfoExtended> Members
    
            private IEnumerator<FileInfoExtended> InternalGetEnumerator()
            {
                List<FileInfoExtended> filesToProcess = null;
    
                do
                {
                    filesToProcess = GetFilesToProcess();
    
                    foreach (var fi in filesToProcess)
                    {
                        yield return fi;
                    }
                }
                while (filesToProcess.Count > 0);
            }
    
            public IEnumerator<FileInfoExtended> GetEnumerator()
            {
                return InternalGetEnumerator();
            }
    
            #endregion
    
            #region IEnumerable Members
    
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return InternalGetEnumerator();
            }
    
            #endregion
        }
    }

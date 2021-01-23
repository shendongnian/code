    public class FileSystemInfoEnumerator: IEnumerator<FileSystemInfo>, IEnumerable<FileSystemInfo> {
      private const string DefaultSearchPattern = "*.*";
    
      private String InitialPath { get; set; }
      private String SearchPattern { get; set; }
      private SearchOption SearchOptions { get; set; }
      private Stack<IEnumerator<FileSystemInfo>> EnumeratorStack { get; set; }
    
      private Action<Exception> ErrorHandler { get; set; }
    
      public FileSystemInfoEnumerator(String path, String pattern = DefaultSearchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, Action<Exception> errorHandler = null) {
    
    	 if (String.IsNullOrWhiteSpace(path))
    		throw new ArgumentException("path cannot be null or empty");
    	 
    	 var dirInfo = new DirectoryInfo(path);
    	 
    	 if(!dirInfo.Exists)
    		throw new InvalidOperationException(String.Format("File or Directory \"{0}\" does not exist", dirInfo.FullName));
    
    	 InitialPath = dirInfo.FullName;
    	 SearchOptions = searchOption;
    	 
    	 if(String.IsNullOrWhiteSpace(pattern)) {
    		pattern = DefaultSearchPattern;
    	 }
    
    	 ErrorHandler = errorHandler ?? DefaultErrorHandler;
    	 EnumeratorStack = new Stack<IEnumerator<FileSystemInfo>>();
    	 SearchPattern = pattern;
    	 EnumeratorStack.Push(GetDirectoryEnumerator(new DirectoryInfo(InitialPath)));
      }
    
      private void DefaultErrorHandler(Exception ex) {
    	 throw ex;
      }
    
      private IEnumerator<FileSystemInfo> GetDirectoryEnumerator(DirectoryInfo directoryInfo) {
    	 var infos = new List<FileSystemInfo>();
    
    	 try {
    		if (directoryInfo != null) {
    		   var info = directoryInfo.GetFileSystemInfos(SearchPattern);
    		   infos.AddRange(info);
    		}
    	 } catch (Exception ex) {
    		ErrorHandler(ex);
    	 }
    
    	 return infos.GetEnumerator();
      }
    
      public void Dispose() {
    	 foreach (var enumerator in EnumeratorStack) {
    		enumerator.Reset();
    		enumerator.Dispose();
    	 }
      }
    
      public bool MoveNext() {
    	 var current = Current;
    
    	 if (ShouldRecurse(current)) {
    		EnumeratorStack.Push(GetDirectoryEnumerator(current as DirectoryInfo));
    	 }
    
    	 var moveNextSuccess = TopEnumerator.MoveNext();
    
    	 while(!moveNextSuccess && TopEnumerator != null) {
    		EnumeratorStack.Pop();
    
    		moveNextSuccess = TopEnumerator != null && TopEnumerator.MoveNext();
    	 }
    
    	 return moveNextSuccess;
      }
    
      public void Reset() {
    	 EnumeratorStack.Clear();
    	 EnumeratorStack.Push(GetDirectoryEnumerator(new DirectoryInfo(InitialPath)));
      }
    
      public FileSystemInfo Current {
    	 get {
    		return TopEnumerator.Current;
    	 }
      }
    
      object IEnumerator.Current {
    	 get {
    		return Current;
    	 }
      }
    
      public IEnumerator<FileSystemInfo> GetEnumerator() {
    	 return this;
      }
    
      IEnumerator IEnumerable.GetEnumerator() {
    	 return GetEnumerator();
      }
      
      IEnumerator<FileSystemInfo> TopEnumerator {
    	 get {
    		if(EnumeratorStack.Count > 0)
    		   return EnumeratorStack.Peek();
    
    		return null;
    	 }
      }
    
      private Boolean ShouldRecurse(FileSystemInfo current) {
    	 return current != null &&
    			IsDirectory(current) &&
    			SearchOptions == SearchOption.AllDirectories;
      }
    
      private Boolean IsDirectory(FileSystemInfo fileSystemInfo) {
    	 return fileSystemInfo != null &&
    			(fileSystemInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory;
      }
    }

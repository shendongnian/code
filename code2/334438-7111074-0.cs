        public void OnResumeBookmark(NativeActivityContext context, Bookmark bookmark, object obj)    {        
            Test t = obj as Text;
            context.SetValue(this.Test1, t.S1);    
            context.SetValue(this.Test2, t.S2);    
        }

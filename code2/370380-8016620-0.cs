     public bool GetVersion(string fileName)
     {
           Assembly asm = null;
           try
           {
                   asm = Assembly.LoadFrom(fileName);
            }
            catch (Exception err)
            {
                   this._errMsg = err.Message;
                   return false;
             }
             if (asm != null)
             {
                   this._info = new AssemblyInformation();
                   this._info.Name = asm.GetName().Name;
                   this._info.Version = asm.GetName().Version.ToString();
                  this._info.FullName = asm.GetName().ToString();
             }
             else
             {
                   this._errMsg = "Invalid assembly";
                   return false;
              } 
              return GetReferenceAssembly(asm);
      }
      public bool GetVersion(Assembly asm)
      {
             if (asm != null)
             {
                  this._info = new AssemblyInformation();
                  this._info.Name = asm.GetName().Name;
                 this._info.Version = asm.GetName().Version.ToString();
                 this._info.FullName = asm.GetName().ToString();
             }
             else
              {
                 this._errMsg = "Invalid assembly";
                 return false;
              }
  
              return GetReferenceAssembly(asm);
        }

    public IEnumerable<BIContactLib> GetContactLibs 
        {
            get { 
                 BiContractLib lib = new BiContractLib();
                 return lib.GetAll();
                }        
        }

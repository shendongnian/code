    interface IBase {
    }
    
    class Alpha : IBase {
    }
    
    class Beta : Alpha {
    }
    
    IList<IBase> ListOfObjects { get; set; }

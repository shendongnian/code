    public ICommonStuff LoadedClass;
    public Init()
    {
        /* load the object, according to which version we need... */
        if (Config.Version == "refA")
        {
            LoadedClass = new WrapperA(new refA());
        }
        else if (Config.Version == "refB")
        {
            LoadedClass = new WrapperB(new refB());
        }
        else if (Config.Version == "refC")
        {
            LoadedClass = new WrapperC(new refC());
        }
        Run();
    }
    private void Run(){
    {
        LoadedClass.SomeProperty...
        LoadedClass.SomeMethod(){ etc... }
    }

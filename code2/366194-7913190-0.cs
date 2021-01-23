    private string name;
    public String Name{
        get{
            if(this.name == String.Empty)
                return "No name given";
            else
                return name;
        }
    }

    public struct Field
    {
       public String Name;
       public Int32 Size;
    
       public Field(String name, Int32 size)
       {
          Name = name;
          Size = size;
       }
       public static implicit operator string(Field d) => d.Name;
    }

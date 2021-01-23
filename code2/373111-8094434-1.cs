    <#
    	
    foreach (Table tablo in tables)
    {
    //start class
    WriteLine("public partial class My" +tablo.Name+"\n{");
    foreach (Column column in tablo.Columns)
    {
    if(column.DataType.Name=="nvarchar")
    WriteLine("\tpublic string " + column.Name+"{get; set;}");
    else
    WriteLine("\tpublic int " + column.Name+"{get; set;}");
    }
    //output the contructor
    WriteLine("\tpublic My" + tablo.Name + "()\n\t{\n\t\t//constructor\n\t}" );
    WriteLine("\tpublic List<" + tablo.Name + "> GetById(int id)\n\t{\n\t\t// do something\n\t}");
    //end class
    WriteLine("}");
    //output comment and start class
    WriteLine("//Delete,Update,Save");
    WriteLine("public partial class My" +tablo.Name+"\n{");
    WriteLine("\tpublic bool Save(My" + tablo.Name + " " + tablo.Name + ")\n\t{\n\t\t// do something\n\t}");
    WriteLine("\tpublic bool Delete(int id)\n\t{\n\t\t// do something\n\t}");
    WriteLine("\tpublic bool Update(int id)\n\t{\n\t\t// do something\n\t}");
    WriteLine("}");
    
    }
    #>

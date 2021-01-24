		 string[] One = new string[3];
            One[0] = "Pen";          
            One[1] = "Pencil";          
            One[2] = "card";
		
		string[] Two = new string[2];
            Two[0] = "card";          
            Two[1] = "drive";
        var nonintersectOne = One.Except(Two);   
		foreach(var str in  nonintersectOne)
		   Console.WriteLine(str);
        // Or if you want the non intersect from both
		var nonintersectBoth = One.Except(Two).Union(Two.Except(One)).ToArray();
		foreach(var str in  nonintersect)
		   Console.WriteLine(str);
Output 1:
> Pen
>
> Pencil
Output 2:
> Pen
>
> Pencil
>
> drive

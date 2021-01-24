// @nuget: Microsoft.EntityFrameworkCore -version 2.2
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;					
public class Program
{
	public static void Main()
	{
		throw new DbUpdateConcurrencyException("message"
          , new List<IUpdateEntry> { null }  );
	}
}

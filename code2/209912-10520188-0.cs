      void WriteMapping(CodeProperty codeProperty)
     {
	   WriteLine("");
       WriteLine("///CodeProperty");
	   WriteLine("///<summary>");
	   WriteLine("///"+codeProperty.FullName);
	   WriteLine("///</summary>");
       if(codeProperty.Getter==null && codeProperty.Setter==null)
           return;
       if(codeProperty.Attributes!=null){
	       foreach(CodeAttribute a in codeProperty.Attributes)
			{
			    Write("["+a.FullName);
			    if(a.Children!=null && a.Children.Count>0)
			    {
		            var start=a.Children.Cast<CodeElement>().First().GetStartPoint();
				    var finish= a.GetEndPoint();
                    string allArguments=start.CreateEditPoint().GetText(finish);
				
				    Write("("+allArguments);
			    }
		WriteLine("]");
			}
			}
       Write("public "+GetFullName(codeProperty.Type) +" "+codeProperty.Prototype);
        
        Write(" {");
        //if(codeProperty.Getter!=null && codeProperty.Getter.Access!=vsCMAccess.vsCMAccessPrivate)
            Write("get;");
        //if(codeProperty.Setter!=null)
            Write("set;");
        WriteLine("}");
        
       }

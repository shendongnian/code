     var destinationfilename = "";
            if (System.IO.File.Exists("nameoffile.dll"))
            {
              destinationfilename = (@helperRoot + System.IO.Path.GetFileName(medRuleBook.Schemapath)).ToLower();
              if (System.IO.File.Exists(destinationfilename)) System.IO.File.Delete(destinationfilename);
              System.IO.File.Copy(@'nameoffile.dll", @destinationfilename);
            }
            // use dll-> XSD
            var returnVal =
              await DoProcess(
                @helperRoot + "xsd.exe", "\"" + @destinationfilename + "\"");
            destinationfilename = destinationfilename.Replace(".dll", ".xsd");
            if (System.IO.File.Exists(@destinationfilename))
            {
              // now use XSD
              returnVal =
                await DoProcess(
                  @helperRoot + "xsd.exe", "/c /namespace:RuleBook /language:CS " + "\"" + @destinationfilename + "\"");
              if (System.IO.File.Exists(@destinationfilename.Replace(".xsd", ".cs")))
              {
                var getXSD = System.IO.File.ReadAllText(@destinationfilename.Replace(".xsd", ".cs"));
               
              }
            }

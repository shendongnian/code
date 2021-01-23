    using System.Xml.Linq;
    string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
    <Commands Version=""439""  CreateUser=""Reda"">
      <CmCommands DataclassId=""57067ca8-ef96-4d2e-a085-6bd7e8b24126"" OrderName = ""Tea"" Remark=""Black"">
        <CmExecutions EntityId=""A9A5B0F2-6AB4-4619-9106-B0F85F86EE01"" Lock=""n"" />
      </CmCommands>
    </Commands>";
    
    XDocument x = XDocument.Parse(xml);
    
    Debug.Print(x.Elements().First().Elements().First().Attributes().Last().Value);
    //                 Commands ^      CmCommands ^             Remark ^

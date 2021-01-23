    XElement xml = new XElement("AnwerList", 
       from anwer in anwerList select
          new XElement("Anwer",
             new XElement("ID", anwer.ID),
             new XElement("XML",
                new XElement("Answer", anwer.Answer)
                )
             )
          );
    Console.Out.WriteLine(xml);
    <AnwerList>
      <Anwer>
        <ID>1</ID>
        <XML>
          <Answer>2</Answer>
        </XML>
      </Anwer>
      ...

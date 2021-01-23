    public class Anwer
    {
        public int ID { get; set; }
        public int Answer { get; set; }
    }
    
    ..
    
    List<Anwer> answerList = new List<Anwer>() {
       new Anwer { ID=1, Answer=2 },
       new Anwer { ID=2, Answer=3 },
    };
    XmlSerializer x = new XmlSerializer(answerList.GetType());
    x.Serialize(Console.Out, answerList);
    
    ..
    
    <ArrayOfAnwer ...>
      <Anwer>
        <ID>1</ID>
        <Answer>2</Answer>
      </Anwer>
      ...

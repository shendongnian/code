    QueueEntity Head;
    QueueEntity Tail
    
    class QueueEntity
    {
           QueueEntity Prev;
           QueueEntity Next;
           ...   //queue content; 
    }
    
    and then do this:
    
    //Read
    lock(Tail)
    {
      //get the content
      Tail=Tail.Prev;
    }
    
    //Write
    lock(Head)
    {
       newEntity = new QueueEntity();
       newEntity.Next = Head ;
       Head = newEntity;
    }

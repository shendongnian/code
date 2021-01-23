       Dim qMsg As Message ' instance of the message to be picked 
            Dim privateQ As New MessageQueue(svrName & "\Private$\" & svrQName) 'variable svrnme = server name ; svrQName = Server Queue Name
            privateQ.Formatter = New XmlMessageFormatter(New Type() {GetType(String)}) 'Formating the message to be readable the body tyep
            Dim t As MessageEnumerator 'declared a enumarater to enable to count the queue
            t = privateQ.GetMessageEnumerator2() 'counts the queues 
            If t.MoveNext() = True Then 'check whether the queue is empty before reading message. otherwise it will wait forever 
                qMsg = privateQ.Receive
                Return qMsg.Body.ToString
            End If

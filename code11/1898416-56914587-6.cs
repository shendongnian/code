            while (true) //--------------------------------- INFINITE LOOP
            {            //----- NEW ARRAY                CREATED PER-LOOP
                var blockArray = Enumerable.Range(0, 30).ToArray();
                         //----- NEW .ForEach(){...}      CREATED PER-LOOP                
                // |||||||||||||||||||||||||||||||||||||||||||||||||||||||PAR||| BLOCK
                Parallel.ForEach(blockArray, (i) =>    // ||||||||||||||||PAR||| BLOCK
                {        //----- NEW QUEUE                CREATED PER-LOOP x PER-BLOCK
                    MessageQueue queue = new MessageQueue(queueName);
                    try
                    {   var message = queue.Receive(TimeSpan.Zero);
                        message.Formatter = new BinaryMessageFormatter();
                        var labelParts = message.Label.Split('_');
                        var isValidMessageAddress=  Validate(labelParts);
                        if (isValidMessageAddress)
                        {
                         //--------------------- PER MESSAGE PAYLOAD PROCESSING START
                         // call my sysnc method
                         //--------------------- PER MESSAGE PAYLOAD PROCESSING END
                        }
                    }
                    catch (MessageQueueException mqex)
                    {   if (mqex.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout)
                        {   return; //-- <<<< ???
                          //------------ EACH IOTimeout KILLS +ONE POOL-MEMBER
                          //------------ 30th IOTimeout LEAVES THE POOL EMPTY
                        }
                        else throw;
                        //-------------- NO ERROR HANDLING
                    }
                });
                // |||||||||||||||||||||||||||||||||||||||||||||||||||||||PAR||| BLOCK
            } //-------------------------------------------- INFINITE-LOOP

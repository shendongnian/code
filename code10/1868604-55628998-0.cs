public static List<string> GetDecodedStaticMsg(string filterMsg)
 {
     try
     {
         var q1 = (from decodemsg in Em.StaticMessages
                   where SqlMethods.Like(decodemsg.Message, $"%{filterMsg}%")  //Changes here
                   select
                   decodemsg.MessageId
                   ).ToList();
                  return q1;
     }
     catch (Exception)
     {
                return null;
     }
 }

      public static MessageQueue CreatePrivate(string name) {
            string path = string.Format(@".\private$\{0}", name);
            if (!MessageQueue.Exists(path)) {
                MessageQueue.Create(path);
                return new MessageQueue(path);
            }
            return new MessageQueue(path);
        }
        public static MessageQueue CreatePublic(string hostname,string queuename) {
            string path = string.Format(@"{0}\{1}", hostname,queuename);
            if (!MessageQueue.Exists(path)) {
                MessageQueue.Create(path);
                return new MessageQueue(path);
            }
            return new MessageQueue(path);
        }
    }

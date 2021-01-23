    string msg = "This is a small message !";
    string otherMsg = "This is a small message !This is a small message !This is a small message !This is a small message !This is a small message !";
    bool isRepeated = Enumerable.Range(0, otherMsg.Length / msg.Length)
                                .Select(i => otherMsg.Substring(i *  msg.Length,  msg.Length))
                                .All( x => x == msg);

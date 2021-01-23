    public override void RunJob(IPacketMsg packet)
    {
        .. // handle packet
        var myReply = new Packet();
        var response = jobManager.GetResponseForReplyAsync(myReply.ReplyId);
        SendReply(myReply);
        await response;
    }

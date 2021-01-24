    private void ProcessRewardNode(XmlTextReader RewardReader)
    {
        XmlDocument RewardXmlDoc = new XmlDocument();
        RewardXmlDoc.LoadXml(RewardReader.ReadOuterXml());
        // we can use xpath as below
        myID = RewardXmlDoc.SelectSingleNode("Reward/myID").InnerText;
    }

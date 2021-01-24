    if (variable==true)
    {
        var Emo = await FaceEmotion.MakeAnalysisRequest(imageFilePath);
        if (Emo[0].FaceAttributes.Emotion.Anger >= 0.5)
        {
           EmoBox.Text = "Anger, Bad Driving Condition, Soft Music will be played";
        }
        ...
           
    }

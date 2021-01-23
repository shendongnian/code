	msg.IsBodyHtml = true;
	AlternateView av = AlternateView.CreateAlternateViewFromString(msg.Body, new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Html));
	av.TransferEncoding = System.Net.Mime.TransferEncoding.SevenBit;
	msg.AlternateViews.Add(av);
	AlternateView avPlain = AlternateView.CreateAlternateViewFromString(msg.Body, new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Plain));
	avPlain.TransferEncoding = System.Net.Mime.TransferEncoding.SevenBit;
	msg.AlternateViews.Add(avPlain); 

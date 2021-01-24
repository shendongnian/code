    f1.addnoise(f1.Imge);
    if(pictureBoxNoisyImg.Image != null)
    {
        pictureBoxNoisyImg.Image.Dispose();
        pictureBoxNoisyImg.Image = null;
    }
    pictureBoxNoisyImg.Image = new Bitmap(f1.Imge);
    f1.meanfilter(SablonBoyutu, f1.Imge);
    if(pBox_PROCESSED.Image != null)
    {
        pBox_PROCESSED.Image.Dispose();
        pBox_PROCESSED.Image = null;
    }
    pBox_PROCESSED.Image = f1.Imge;

    void CompositionTarget_Rendering(object sender, EventArgs e)
    {         
        if (DetectCollisionLeft(myCat, myZero))
        {
            LayoutRoot.Children.Remove(myZero);
            
            //Update the score as score = previousScore + 1
            int scoreAsInt;
            if(Int32.TryParse(score.Text, NumberStyles.Integer, CultureInfo.CurrentCulture, out scoreAsInt) != null)
            {
                scoreAsInt = scoreAsInt + 1;
                score.Text = scoreAsInt.ToString(CultureInfo.CurrentCulture);
            }
        }
    }

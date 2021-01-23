    public function UpdateIfAsked(string name)
    {
        var item = this.SurveyInfo[name];
        if (item != null)
        {
            // Update the itme or remove it.
            if (item.Asked && item.Date < DateTime.Today)
            {
                SurveyInfo.Remove(item);
            }
        }
    }

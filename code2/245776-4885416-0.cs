    public void AddSticker(StickerBase sticker)
    {
        if (sticker.GetValidator() != null)
        {
            this.validator = sticker.GetValidator();
            // add the sticker to the list
        }
        else
        {
            if (this.validator == null || this.validator.validate(sticker))
            {
                // add the sticker to the list
            }
            else
            {
                // set error state
            }
        }
    }

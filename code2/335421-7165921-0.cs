      try
      {
        unitOfWork.BeginTransaction();
        var custom = this.customPhraseRepository.FindCustomPhraseByPhrase(customPhrase);
        if (custom == null)
        {
          custom = new CustomPhrase() { Phrase = customPhrase };
          this.customPhraseRepository.Add(custom);
        }
        var english = this.englishPhraseRepository.FindEnglishPhraseByPhrase(englishPhrase);
        if (english == null)
        {
          english = new EnglishPhrase() { Phrase = englishPhrase };
          this.englishPhraseRepository.Add(english);
        }
        custom.AddTranslation(english);
        this.customPhraseRepository.Update(custom);
        unitOfWork.EndTransaction();
      }
      catch (Exception)
      {
        unitOfWork.RollBack();
      }
      finally
      {
        unitOfWork.Dispose();
      }

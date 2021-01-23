      if (person.PersonDetails.Count != responses.Length)
        throw new ArgumentOutOfRangeException("Arrays are different lengths");
      bool result = true;
      for (int i = 0; i < person.PersonDetails.Count; i++)
      {
        if (person.PersonDetails[i].Correct != responses[i])
        {
          result = false;
          break;
        }
      }

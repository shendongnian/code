            foreach (Button userInput in userInputs)
        {
     for (i = 0; i < userInputs.Length; i++)
                {
                        if (userInput.GetComponentInChildren<TextMeshProUGUI>().text 
            == correctAnswers[i].ToString())
                        {
                            userInput.GetComponent<Image>().color = Color.green;
                        }
                        else
                        {
                            {
                                userInput.GetComponent<Image>().color = Color.red;
                            }
                        }
        }
            }

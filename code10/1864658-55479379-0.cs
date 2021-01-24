            // Available Design Count Text
            addTestStep("The Design Selection Available Design Text Matches the Expected Text");
            string availableDesignCountText = designSelectionPage.designSelectionAvailableDesignCountText.Text.ToLower().Trim();
            bool textMatches = System.Text.RegularExpressions.Regex.IsMatch(availableDesignCountText, @"^\d+\s+(?:of|de)\s+\d+$");
            TestReporter.assertTrue(textMatches,
                "The Design Selection Page Available Design Text Didn't Match the Expected Format [" + availableDesignCountText + "]");
            addTestStep("Complete");
This ended up doing the trick!

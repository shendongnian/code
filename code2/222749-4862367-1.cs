            using (IE ie = new IE(facebookUrl))
            {
                ie.TextField(Find.ByName("xhpc_message")).Focus();
                ie.TextField(Find.ByName("xhpc_message")).TypeTextQuickly(numText);
                ie.Button(Find.ByValue("Share")).Click();
            }

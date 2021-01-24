string temp = textArray[rowsToReadFrom[0]];
temp = System.Text.RegularExpressions.Regex.Replace(temp, @"\s", "");
char[] chArr = temp.ToCharArray();
Then put it on a button like this
foreach (char c in chArr)
        {
            testObject clone = Instantiate(prefab.gameObject).GetComponent<testObject>();
            clone.transform.SetParent(container);
            charObjects.Add(clone.Init(c));
            //Debug.Log(c);
        }

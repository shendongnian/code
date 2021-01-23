    string[] words = q.ToLower().Split(' ');
    string[] wordsFixed = new string[] {"", "", "", "", "", "" };
    for(int i = 0; i < 6 && i < words.Length; i++)
        wordsFixed[i] = words[i];
        var data = from item in list
                        where (item.ID + item.Name + item.Address1 + item.Address2 + item.PostCode).ToLower().Contains(wordsFixed[0]) &&
                              (item.ID + item.Name + item.Address1 + item.Address2 + item.PostCode).ToLower().Contains(wordsFixed[1]) &&
                              (item.ID + item.Name + item.Address1 + item.Address2 + item.PostCode).ToLower().Contains(wordsFixed[2]) &&
                              (item.ID + item.Name + item.Address1 + item.Address2 + item.PostCode).ToLower().Contains(wordsFixed[3]) &&
                              (item.ID + item.Name + item.Address1 + item.Address2 + item.PostCode).ToLower().Contains(wordsFixed[4]) &&
                              (item.ID + item.Name + item.Address1 + item.Address2 + item.PostCode).ToLower().Contains(wordsFixed[5])
                        select item;

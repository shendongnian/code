cs
private void AssignEven()
        {
            for (int i = 1; i <= maxCorrect;)
            {
                 randomChild = children[UnityEngine.Random.Range(0, children.Count)];
                if(randomChild.GetComponent<Tile>()._IsCorrect == false)
                {
                    int maxLength = evenNumbers.Count;
                    int tempTileNum = evenNumbers[UnityEngine.Random.Range(0, maxLength)];
                    randomChild.GetComponent<Tile>()._TileNumber = tempTileNum;
                    randomChild.GetComponent<Tile>()._IsCorrect = true;
                    correctOnBoard++;
                    randomChild.GetComponent<SpriteRenderer>().sprite = numberSprite[tempTileNum - 1];
                    Debug.Log(tempTileNum);
                    i++;
                }
            }
        }
    ```
Thanks to John Wu!

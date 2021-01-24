    for (int i = 3; i <= 7; i += 2)
    {
       if ((AngelsCount.AngelValue / DevilsCount.DevilsValue) >= i)
       {
          this.gameObject.GetComponent<SpriteRenderer>().sprite = GetAngelStage((i - 3)/2);
       }
    }

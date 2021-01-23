    void SetNewRecord<T>()
    {
         var list = GridView.DataSource as T;
         for (int i = 0; i < list.Length; i++)
         {
              if (list[i].KOD == kod)
              {
                   GridView.CurrentCell = GridView[0, i];
                   return;
              }
          }
    }

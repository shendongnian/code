    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("OrderingPoint")) return;
    
        int rand = Random.Range(0, 3);
        // First deactivate all pictures because as I understand you want to show only one
        foreach(var icon in OrderPicture)
        {
            icon.SetActive(false);
        }
        // Show the icon according to the random index
        OrderPicture[rand].SetActive(true);
       
        switch (rand)
        {
            case 0:
                if (collision.gameObject.name == "Rendang")
                {
                    GetRendang();
                }               
                //RecipeObject.Artwork.SetActive(false);
                break;
            case 1:
                //CuisineObject.Artwork.SetActive(true);
                if (collision.gameObject.name == "Gado Gado")
                {
                    GetGadoGado();
                }
                //RecipeObject.Artwork.SetActive(false);
                break;
            case 2:
                if (collision.gameObject.name == "Soto")
                {
                    GetSoto();
                }
                //CuisineObject.Artwork.SetActive(false);
                break;
        }
    }

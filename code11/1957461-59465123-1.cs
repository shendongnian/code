static int count = 0;
if (ad1 != null){
     if(count == 4)
     {
       count = 0;
       ad1.Show();
     } else {
     count++;
     }
                    
}
Full Code:
[System.Obsolete]
   static int count = 0;
    [System.Obsolete]
    void Start()
    {
        Monetization.Initialize(store_id, true);
    }
    [System.Obsolete]
    void OnCollisionEnter(Collision info)
    {
        if (info.collider.tag == "Obstacle3")
        {
            if (Monetization.IsReady(video_ad))
            {
                ShowAdPlacementContent ad1 = null;
                ad1 = Monetization.GetPlacementContent(video_ad) as ShowAdPlacementContent;
                if (ad1 != null)
                {
                    if(count == 4)
                    {
                        count = 0;
                        ad1.Show();
                    }
                    else
                    {
                        count++;
                    }
                    
                }
             
            }
        }
  [1]: https://answers.unity.com/users/445540/hellium.html

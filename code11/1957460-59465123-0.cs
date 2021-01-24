private static int count = 0;
if (ad1 != null){
     count++;
     if(count % 3 == 0){
     ad1.Show();
     }                   
}
Thanks to [Hellium][1]
Full Code:
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
                    count++;
                    if(count % 3 == 0)
                    {
                        ad1.Show();
                    }
                    
                }
             
            }
        }
  [1]: https://answers.unity.com/users/445540/hellium.html

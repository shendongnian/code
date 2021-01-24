    using System.Lynq;
    ...
    if (Input.GetButtonDown("Jump") && other.tag == "PlayerCollider")
    {
        var todestroy = Spawner.GetComponentsInChildren<Mandibula>(true).Where(m => m.Contar_Espaços());
        foreach(var mand in todestroy) 
        {
            Destroy(mand.gameObject);
        }   
    }

    AnimatorClipInfo[] m_AnimClipInf;
    string m_ClipName;
    void Start()
    {
    //Set up our projectile for possible Elimination
    //upon Collision
    Getcomponent<Animator>().SetBool("Elim", false);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
     m_AnimClipInf = col.GetComponent<Animator> 
     ().GetCurrentAnimatorClipInfo(0);
     m_ClipName = m_AnimClipInf[0].clip.name;
     
     if (m_ClipName == "Defending")
     {
     GetComonent<Animator>().SetBool("Elim", true);
     //Projectile gets eliminated
     }
    }

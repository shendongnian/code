    //External(?) dependencies
    public Transform player;
    public LayerMask playerLayerMask; //From: whatIsPlayer
    
    //Internal dependencies
    public Animator animator; //From: anim
    
    //Settings
    public int health; //From: Health
    public float range;
    public float speed;
    public int damage;
    public float attackInterval; //From: timeBtwAttack
    
    //Gobling stuff (probably redundant/unnecessary)
    public Transform goblin; //From: goblinRange
    public float goblinAttackRange; //From: attackRangeGoblin
    //Used in the answer, as infered from the question
    public float minDistance; //Probably what 'goblinAttackRange' is.

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public enum EnemyState
    {
      Wander,
      Follow,
      Die,
    };
    public class EnemyController : MonoBehaviour
    {
      GameObject player;
      public EnemyState currState = EnemyState.Wander;
      public Transform target;
      Rigidbody2D myRigidbody;
      public float range = 2f;
      public float moveSpeed = 2f;
 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
     
        switch (currState)
        {
            case (EnemyState.Wander):
                Wander();
                break;
            case (EnemyState.Follow):
                Follow();
                break;
            case (EnemyState.Die):
               // Die();
                break;
        }    
        if(IsPlayerInRange(range) && currState != EnemyState.Die)
        {
            currState = EnemyState.Follow;
        }
        else if(!IsPlayerInRange(range)&& currState != EnemyState.Die)
        {
            currState = EnemyState.Wander;
        }
    }
    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }
    bool isFacingRight()
    {
        return transform.localScale.x > 0;
    }
    void Wander()
    {
        {
            if (isFacingRight())
            {
                myRigidbody.velocity = new Vector2(moveSpeed, 0f);
            }
            else
            {
                myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
            }
        }
     
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), 1f);
        
    }
    void Follow()
    {
        if (transform.position.x > target.position.x)
        {
            //target is left
            transform.localScale = new Vector2(-1, 1);
            myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), moveSpeed * Time.deltaTime);
        }
        else if (transform.position.x < target.position.x)
        {
            //target is right
            transform.localScale = new Vector2(1, 1);
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), moveSpeed * Time.deltaTime);
        }
    }
}

    using UnityEngine;
    using System.Collections;
	 
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour {
    	public Vector3 jump;
    	public float jumpForce = 2.0f;
		
    	public bool isGrounded;
    	Rigidbody rb;
    	void Start(){
    		rb = GetComponent<Rigidbody>();
    		jump = new Vector3(0.0f, 2.0f, 0.0f);
    	}
    	void OnCollisionStay(){
    		isGrounded = true;
    	}
    	void Update(){
    		if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
    			rb.AddForce(jump * jumpForce, ForceMode.Impulse);
    			isGrounded = false;
	    	}
	    }
    }

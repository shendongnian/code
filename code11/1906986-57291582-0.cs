bool btnPressed = false;
void Update(){
    if(Input.GetMouseButton(0) && !btnPressed){
        btnPressed = true;
    }
}
void FixedUpdate(){
    if(btnPressed){
        if(change == true){
            rb.velocity = new Vector2(-12,rb.velocity.y);
            change=!change;
        }
        else if(change == false){
            change=!change;
            rb.velocity = new Vector2(12,rb.velocity.y);
        }
        btnPressed = false;
    }
}

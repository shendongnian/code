        void LadderSystem()
        {
            if (m_movementInputData.IsClimbing)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                {
                    Vector3 _verticalDir = (Input.GetKey(KeyCode.W)) ? Transform.up : Transform.down;
                    Vector3 _yDir = _verticalDir * m_climbSpeed * Input.GetAxis("Vertical");
                    Vector3 _zDir = Vector3.zero;
                    if (m_movementInputData.IsClimbingExtremity)
                    {
                        _zDir = transform.forward * m_climbSpeed * Input.GetAxis("Vertical");
                    }
                    m_characterController.Move((_yDir + _zDir) * Time.deltaTime);
                }
            }
        }
        void OnTriggerEnter(Collider col)
        {
            if (col.tag == "Ladder")
            {
                m_movementInputData.IsClimbing = true;
            }
            if (col.tag == "Ladder Extremity")
            {
                m_movementInputData.IsClimbingExtremity = true;
            }
        }
        void OnTriggerExit(Collider col)
        {
            if (col.tag == "Ladder")
            {
                m_movementInputData.IsClimbing = false;
            }
            if (col.tag == "Ladder Extremity")
            {
                m_movementInputData.IsClimbingExtremity = false;
            }
        }

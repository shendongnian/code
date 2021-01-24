            void LadderSystem()
            {
                if (m_movementInputData.IsClimbing)
                {
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                    {
                        Vector3 _verticalDir = (Input.GetKey(KeyCode.W)) ? Transform.up : Transform.down;
                        Vector3 _yDir = _verticalDir * m_climbSpeed * Input.GetAxis("Vertical");
                        Vector3 _zDir = transform.forward * m_climbSpeed;
                        m_characterController.Move((_yDir + _zDir) * Time.deltaTime);
                    }
                }
            }

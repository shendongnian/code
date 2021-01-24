    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    //this is the editor interface into which I input the demands
    [System.Serializable]
    struct Transform_Angle_VP
    {
        public float angle1;
        public float angle2;
        public float max_speed;
        public Transform[] transforms;
    }
    
    public class LeftCollectionDarkMovement : MonoBehaviour
    {
    
        public float speed_change;
        [SerializeField] Transform_Angle_VP[] transform_Angles;
        Dictionary<Transform, float[]> TransAngs = new Dictionary<Transform, float[]>();
    
        // Use this for initialization
        void Awake()
        {
            //rewrite transforms and their angle limits into dictionary to keep seperate track of each
            foreach (Transform_Angle_VP T_A_VP in transform_Angles)
            {
                foreach (Transform trans in T_A_VP.transforms)
                {
                    ///float[0:min_angle, 1:max_angle, 2:target_angle, 3:current_speed, 4:target_speed, 5:max_speed, 6: current_rotation]
                    TransAngs[trans] = new float[] { T_A_VP.angle1, T_A_VP.angle2, Random.Range(T_A_VP.angle1, T_A_VP.angle2), 0, Random.Range(T_A_VP.max_speed / 5, T_A_VP.max_speed), T_A_VP.max_speed, 0 };
                }
            }
        }
    
        // Update is called once per frame
        void Update()
        {
            float dt = Time.deltaTime;
            foreach (Transform trans in TransAngs.Keys)
            {
                var parameters = TransAngs[trans];
                //move speed towards target
                parameters[3] = Mathf.Min(parameters[4], parameters[3] + dt * speed_change);
    
                //calculate rotation of target
                var target_rot = Mathf.MoveTowards(parameters[6], parameters[2], parameters[3] * dt);
                target_rot -= parameters[6];
    
                //apply rotation
                trans.Rotate(Vector3.right, target_rot, Space.Self);
                parameters[6] += target_rot;
    
                if (Mathf.Abs(parameters[6] - parameters[2]) < 1)
                {
                    parameters[2] = Random.Range(parameters[0], parameters[1]);
                    parameters[4] = Random.Range(parameters[5] / 5, parameters[5]);
                }
            }
        }
    }

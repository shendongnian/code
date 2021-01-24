     using UnityEngine;
     using System.Collections;
     using System.Collections.Generic;
     [RequireComponent(typeof(LineRenderer))]
     public class LineCollider : MonoBehaviour
     {
         LineRenderer line;
         public void Start() {
             AddCollider(6); //Increase the count of parts(6) if you want to get more detailed collider
         }
         public void AddCollider(int part)
         {
             try
             {
                 line = GetComponent<LineRenderer>();
                 var start = line.GetPosition(0);
                 var end = line.GetPosition(line.positionCount - 1);
                 var a = (line.positionCount - 1) / part;
                 for (int i = 1; i<=part; i++)
                 {
                     if (i == 1)
                         AddColliderToLine(start, line.GetPosition(Mathf.CeilToInt(a * 1)));
                     else if (i == part)
                         AddColliderToLine(line.GetPosition(Mathf.CeilToInt(a * (i - 1))), end);
                     else
                         AddColliderToLine(line.GetPosition(Mathf.CeilToInt(a * (i - 1))), line.GetPosition(Mathf.CeilToInt(a * i)));
                 }            
             }
             catch
             {
                 Destroy(gameObject);
             }
         }
         private void AddColliderToLine(Vector3 start, Vector3 end)
         {
             var startPos = start;
             var endPos = end;
             BoxCollider col = new GameObject("Collider").AddComponent<BoxCollider>();
             col.transform.parent = line.transform;
             float lineLength = Vector3.Distance(startPos, endPos);
             col.size = new Vector3(lineLength, 0.175f, 0.25f);
             Vector3 midPoint = (startPos + endPos) / 2;
             col.transform.position = midPoint;
             float angle = (Mathf.Abs(startPos.y - endPos.y) / Mathf.Abs(startPos.x - endPos.x));
             if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x))
             {
                 angle *= -1;
             }
             angle = Mathf.Rad2Deg * Mathf.Atan(angle);
             col.transform.Rotate(0, 0, angle);
         }
     }

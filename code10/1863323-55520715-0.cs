 using UnityEngine;
 
 [CreateAssetMenu()]
 public class Character : ScriptableObject
 {
     public string Name;
 }
OpinionsTable.cs
using UnityEngine;
 
 
 [CreateAssetMenu()]
 public class OpinionsTable : ScriptableObject
 {
     [SerializeField]
     private Character[] characters;
 
     [SerializeField]
     private int[] opinions;
     public int GetOpinion( Character character1, Character character2 )
     {
         for( int i = 0 ; i < characters.Length ; ++i )
         {
             if( character1 == characters[i] )
             {
                 for( int j = 0 ; j < characters.Length ; ++j )
                 {
                     if( character2 == characters[j] )
                         return opinions[i * characters.Length + j];;
                 }
                 Debug.LogError( "Character2 not found" );
             }
         }
         Debug.LogError( "Character1 not found" );
         return -1;
     }
     public void SetOpinion( Character character1, Character character2, int opinion )
     {
         for( int i = 0 ; i < characters.Length ; ++i )
         {
             if( character1 == characters[i] )
             {
                 for( int j = 0 ; j < characters.Length ; ++j )
                 {
                     if( character2 == characters[j] )
                     {
                         opinions[i * characters.Length + j] = opinion;
                         return ;
                     }
                 }
                 Debug.LogError( "Character2 not found" );
             }
         }
         Debug.LogError( "Character1 not found" );
     }
 }
**In a Folder Called 'Editor'**
OpinionsTableEditor.cs
 using UnityEngine;
 using UnityEditor;
 
 [CustomEditor( typeof( OpinionsTable ) )]
 public class OpinionsTableEditor : Editor
 {
     const float opinionsLabelWidth = 50;
     const float opinionCellSize = 25;
     SerializedProperty characters;
     SerializedProperty opinions;
     int opinionsTableWidth = 0;
     Rect opinionsTableRect;
 
     void OnEnable()
     {
         // Retrieve the serialized properties
         characters = serializedObject.FindProperty( "characters" );
         opinions = serializedObject.FindProperty( "opinions" );
     }
 
     public override void OnInspectorGUI()
     {
         serializedObject.Update();
 
         // Check if the number of characters has been changed
         // If so, resize the opinions
         EditorGUI.BeginChangeCheck();
         EditorGUILayout.PropertyField( characters, true );
         if( EditorGUI.EndChangeCheck() )
         {
             opinions.arraySize = characters.arraySize * characters.arraySize;
         }
 
         // Draw opinions if there is more than one character
         if ( opinions.arraySize > 1 )
             DrawOpinions( opinions, characters );
         else
             EditorGUILayout.LabelField( "Not enough characters to draw opinions matrix" );
 
         serializedObject.ApplyModifiedProperties();
     }
 
     private void DrawOpinions( SerializedProperty opinions, SerializedProperty characters )
     {
         int charactersCount = characters.arraySize;
         if ( Event.current.type == EventType.Layout )
             opinionsTableWidth = Mathf.FloorToInt( EditorGUIUtility.currentViewWidth );
 
         // Get the rect of the whole matric, labels included
         Rect rect = GUILayoutUtility.GetRect(opinionsTableWidth, opinionsTableWidth, EditorStyles.inspectorDefaultMargins);
 
         if ( opinionsTableWidth > 0 && Event.current.type == EventType.Repaint )
             opinionsTableRect = rect;
 
         // Draw matrix and labels only if the rect has been computed
         if( opinionsTableRect.width > 0 )
         {
             // Compute size of opinion cell
             float cellWidth     = Mathf.Min( (opinionsTableRect.width - opinionsLabelWidth) / charactersCount, opinionCellSize );
             Rect opinionCell    = new Rect( opinionsTableRect.x + opinionsLabelWidth, opinionsTableRect.y + opinionsLabelWidth, cellWidth, cellWidth );
             Matrix4x4 guiMatrix = GUI.matrix;
 
             // Draw vertical labels
             for ( int i = 1 ; i <= charactersCount ; ++i )
             {
                 Rect verticalLabelRect = new Rect( opinionsTableRect.x + opinionsLabelWidth + i * opinionCell.width, opinionsTableRect.y, opinionsLabelWidth, opinionsLabelWidth );
                 Character character = characters.GetArrayElementAtIndex( i - 1 ).objectReferenceValue as Character;
                 EditorGUIUtility.RotateAroundPivot( 90f, new Vector2( verticalLabelRect.x, verticalLabelRect.y ) );
                 EditorGUI.LabelField( verticalLabelRect, character == null ? "???" : character.Name );
                 GUI.matrix = guiMatrix;
             }            
 
             // Draw matrix
             for ( int i = 0 ; i < charactersCount ; ++i )
             {
                 // Draw horizontal labels
                 SerializedProperty characterProperty = characters.GetArrayElementAtIndex( i );
                 Character character = characterProperty == null ? null : characters.GetArrayElementAtIndex( i ).objectReferenceValue as Character;
                 EditorGUI.LabelField( new Rect( opinionsTableRect.x, opinionCell.y, opinionsLabelWidth, opinionCell.height ), character == null ? "???" : character.Name ) ;
 
                 for ( int j = 0 ; j < charactersCount ; ++j )
                 {
                     opinionCell.x = opinionsTableRect.x + opinionsLabelWidth + j * cellWidth;
                     if ( j > i )
                     {
                         SerializedProperty opinion = opinions.GetArrayElementAtIndex( i * charactersCount + j );
                         opinion.intValue = EditorGUI.IntField( opinionCell, opinion.intValue );
                     }
                     else // Put grey box because the matrix is symmetrical
                     {
                         EditorGUI.DrawRect( opinionCell, Color.grey );
                     }
                 }
                 opinionCell.y += cellWidth; 
             }
         }
     }
 }
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/uE732.png
**Note**
If you want to extend your code a bit further like Character A will have an Opinion of Character B. But Character B will also have an opinion about Character A. Then do the following changes in OpinionsTableEditor.cs
Change this
 for ( int j = 0 ; j < charactersCount ; ++j )
              {
                  opinionCell.x = opinionsTableRect.x + opinionsLabelWidth + j * cellWidth;
                  if ( j > i )
                  {
                      SerializedProperty opinion = opinions.GetArrayElementAtIndex( i * charactersCount + j );
                      opinion.intValue = EditorGUI.IntField( opinionCell, opinion.intValue );
                  }
                  else // Put grey box because the matrix is symmetrical
                  {
                      EditorGUI.DrawRect( opinionCell, Color.grey );
                  }
              }
To This
 for ( int j = 0 ; j < charactersCount ; ++j )
              {
                  opinionCell.x = opinionsTableRect.x + opinionsLabelWidth + j * cellWidth;
                  SerializedProperty opinion = opinions.GetArrayElementAtIndex( i * charactersCount + j );
                  opinion.intValue = EditorGUI.IntField( opinionCell, opinion.intValue );
              }

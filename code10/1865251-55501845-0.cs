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

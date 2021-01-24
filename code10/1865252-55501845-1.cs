    for ( int j = 0 ; j < charactersCount ; ++j )
    {
        opinionCell.x = opinionsTableRect.x + opinionsLabelWidth + j * cellWidth;
        SerializedProperty opinion = opinions.GetArrayElementAtIndex( i * charactersCount + j );
        opinion.intValue = EditorGUI.IntField( opinionCell, opinion.intValue );
    }

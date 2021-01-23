    <class name="Question">
      ...
      <discriminator column="QuestionType"/>
      <subclass name="JobVelocityQuestion">
        <property name="InputtedAnswer"/>
      </subclass>
      <subclass name="NormalQuestion">
        <property name="InputtedAnswer"/>
        <subclass name="AsConsQuestion"/>
        ...
      </subclass>
